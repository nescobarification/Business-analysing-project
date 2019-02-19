// @flow
import { AsyncStorage } from "react-native";
import { URL } from "react-native-dotenv";
import { ReduxState, MetricReducerState, MetricReducerUpload } from "../reducers/state-typed";

export function metricPageChange(dispatch: Function, getState: () => ReduxState) {
    const timerStarted = getState().metricReducer.option.timerStarted;
    if (!timerStarted) {
        metricStart(dispatch, getState);
    } else {
        metricStop(dispatch, getState);

        // Restart the timer for the new page
        metricStart(dispatch, getState);
    }
}

export function metricStart(dispatch: Function, getState: () => ReduxState) {
    const state = getState();
    const featureIds = getMetaDataFeatureIdsFromState(state);
    const timerStarted = state.metricReducer.option.timerStarted;
    if (!timerStarted) {
        dispatch(setFeatures(featureIds));
        dispatch(startTimer(new Date()));
    }
}

function getMetaDataFeatureIdsFromState(state: ReduxState) {
    const pdfId = state.pdfReducer.pdfId;
    const page = state.pdfReducer.currentPage;
    const pdf = state.libraryReducer.list.find(i => i.id === pdfId);

    if (pdf === undefined) {
        return [];
    }

    const pdfPage = pdf.metadata.find(i => i.page === page);
    if (pdfPage === undefined) {
        return [];
    }

    return pdfPage.features.map(i => i.id);
}

export function metricStop(dispatch: Function, getState: () => ReduxState) {
    const option = getState().metricReducer.option;
    const timerStarted = option.timerStarted;
    if (timerStarted) {
        dispatch(stopTimer());
        const duration = new Date() - option.timeStart;
        dispatch(saveFeatures(option.featureIds, new Date(), duration));
    }
}

export async function metricSaveToStorage(metricReducerState: MetricReducerState) {
    const pdfId = metricReducerState.pdfId.toString();

    let featuresToSave = metricReducerState.features;
    const previousFeaturesJson = await AsyncStorage.getItem(pdfId);
    if (previousFeaturesJson !== null) {
        const previousFeatures = JSON.parse(previousFeaturesJson);
        featuresToSave = previousFeatures.concat(featuresToSave);
    }

    await AsyncStorage.setItem(pdfId, JSON.stringify(featuresToSave));
    await savePdfIdToStorage(pdfId);
}

async function savePdfIdToStorage(pdfId: string) {
    const pdfIdsJson = await AsyncStorage.getItem("PdfIds");

    let pdfIds = new Set();
    if (pdfIdsJson !== null) {
        pdfIds = new Set(JSON.parse(pdfIdsJson));
    }

    pdfIds.add(pdfId);
    await AsyncStorage.setItem("PdfIds", JSON.stringify(Array.from(pdfIds)));
}

function setFeatures(ids: Array<number>) {
    return {
        type: "METRIC_SET_FEATURES",
        ids,
    };
}

function saveFeatures(ids: Array<number>, date: Date, duration: number) {
    const data = ids.map(i => {
        return {
            featureId: i,
            date,
            duration,
        };
    });

    return {
        type: "METRIC_SAVE_FEATURES",
        data,
    };
}

function startTimer(date: Date) {
    return {
        type: "METRIC_TIMER_STARTED",
        date,
    };
}

function stopTimer() {
    return {
        type: "METRIC_TIMER_STOPPED",
    };
}

export async function syncWithServer(dispatch: Function, token: string) {
    dispatch(syncStarted());

    const data = await getMetricUpload();

    try {
        // TODO check if we have internet connection
        console.log(URL + "/api/sync/upload/");
        const res = await fetch(URL + "/api/sync/upload/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            await deleteMetricStorage();
            dispatch(syncFinished());
        } else {
            dispatch(syncFailed(res.toString()));
        }

    } catch (e) {
        dispatch(syncFailed(e.toString()));
        console.log(e);
    }
}

function syncStarted() {
    return {
        type: "METRIC_SYNC_STARTED",
    };
}

function syncFinished() {
    return {
        type: "METRIC_SYNC_FINISHED",
        lastSyncDate: new Date(),
    };
}

function syncFailed(message: string) {
    return {
        type: "METRIC_SYNC_FAILED",
        message,
    };
}

async function getMetricUpload() {
    const pdfIdsJson = await AsyncStorage.getItem("PdfIds");
    const pdfIds: Array<string> = JSON.parse(pdfIdsJson);

    let data: Array<MetricReducerUpload> = [];
    for (let i = 0; i < pdfIds.length; i++) {
        const features =  await AsyncStorage.getItem(pdfIds[i]);

        if (features !== null) {
            data.push({
                pdfId: pdfIds[i],
                features: JSON.parse(features)
            });
        }
    }

    return data;
}

export async function deleteMetricStorage() {
    const pdfIdsJson = await AsyncStorage.getItem("PdfIds");

    if (pdfIdsJson !== null) {
        const pdfIds: Array<string> = JSON.parse(pdfIdsJson);
        await AsyncStorage.multiRemove(pdfIds);
        await AsyncStorage.removeItem("PdfIds");
    }
}
