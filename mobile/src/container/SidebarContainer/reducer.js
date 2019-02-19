// @flow
import produce from "immer";
import { SidebarReducerState } from "../../reducers/state-typed";

const initialState = {
    downloadOnlyMode: false,
};

const sidebarReducer = (state: SidebarReducerState = initialState, action: Function) =>
    produce(state, draft => {
        switch (action.type) {
            case "DOWNLOADONLY_MODE_UPDATE":
                draft.downloadOnlyMode = !state.downloadOnlyMode;
                break;
        }
    });

export default sidebarReducer;
