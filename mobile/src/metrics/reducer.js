// @flow
import produce from "immer";
import { MetricReducerState } from "../reducers/state-typed";

const initialState = {
    pdfId: -1,
    features: [],
    option: {
        featureIds: [],
        timerStarted: false,
        timeStart: new Date(0),
    },
    sync: {
        status: "FINISHED",
        lastSyncDate: new Date(0),
        errorMessage: "",
    },
};

const metricReducer = (state: MetricReducerState = initialState, action: Function) =>
    produce(state, draft => {
        switch (action.type) {
            case "PDF_LOADED":
				draft.pdfId = action.data.id;
                break;
            case "METRIC_SET_FEATURES":
                draft.option.featureIds = action.ids;
                break;
            case "METRIC_SAVE_FEATURES":
                draft.features = state.features.concat(action.data);
                break;
            case "METRIC_TIMER_STARTED":
                draft.option.timerStarted = true;
				draft.option.timeStart = action.date;
                break;
            case "METRIC_TIMER_STOPPED":
                draft.option.timerStarted = false;
                break;
            case "METRIC_SYNC_STARTED":
                draft.sync.status = "STARTED";
                break;
            case "METRIC_SYNC_FINISHED":
                draft.sync.status = "FINISHED";
                draft.sync.lastSyncDate = action.lastSyncDate;
                break;
            case "METRIC_SYNC_FAILED":
                draft.sync.status = "ERROR";
                draft.sync.errorMessage = action.message;
                break;
			case "PDF_EXIT":
                draft.pdfId = -1;
                draft.features = [];
                draft.option = initialState.option;
                break;
        }
    });

export default metricReducer;
