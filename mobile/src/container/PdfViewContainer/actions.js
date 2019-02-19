// @flow
import { metricPageChange, metricStart, metricStop, metricSaveToStorage, syncWithServer } from "../../metrics/api";
import { PdfReducerState, ReduxState } from "../../reducers/state-typed";

export function onLoadComplete(numberOfPages: number, filePath: string) {
    return (dispatch: Function, getState: () => ReduxState) => {
		const id = getState().pdfReducer.pdfId;
		dispatch(pdfLoaded(id, numberOfPages, filePath));
		// start the metric collection
	};
}

export function onPageChanged(currentPage: number, numberOfPage: number) {
	return (dispatch: Function, getState: () => ReduxState) => {
		dispatch(pdfPageChange(currentPage, numberOfPage));
		metricPageChange(dispatch, getState);
	};
}

export function onRotate() {
	return {
		type: "PDF_ROTATE"
	};
}

export function onExit() {
	return async (dispatch: Function, getState: () => ReduxState) => {
		metricStop(dispatch, getState);

		const metricReducerState = getState().metricReducer;
		await metricSaveToStorage(metricReducerState);

		const pdfReducerState = getState().pdfReducer;
		dispatch(pdfExit(pdfReducerState));

		const token = getState().authReducer.token;
		await syncWithServer(dispatch, token);
	};
}

export function onAppStateChanged(nextState: string) {
	return (dispatch: Function, getState: () => ReduxState) => {
		const currentState = getState().pdfReducer.appState;
		if (currentState !== nextState) {
			dispatch(appStateChanged(nextState));

			switch (nextState) {
				case "active":
					metricStart(dispatch, getState);
					break;
				case "background":
				case "inactive":
					metricStop(dispatch, getState);
					break;
				default:
					break;
			}
		}
	};
}

function appStateChanged(nextState: string) {
	return {
		type: "APPSTATE_CHANGED",
		nextState,
	};
}

function pdfLoaded(id: number, numberOfPages: number, filePath: string) {
	return {
		type: "PDF_LOADED",
		data: {
			id,
			numberOfPages,
			filePath,
		},
	};
}

function pdfPageChange(currentPage: number, numberOfPage: number) {
	return {
		type: "PDF_PAGE_CHANGED",
        data: {
            currentPage,
            numberOfPage,
        },
	};
}

function pdfExit(data: PdfReducerState) {
	return {
		type: "PDF_EXIT",
		data,
	};
}
