// @flow
import produce from "immer";
import { AuthReducerState } from "../../reducers/state-typed";

const initialState: AuthReducerState = {
    isLoggedIn: false,
    token: "",
};

const libraryReducer = (state: AuthReducerState = initialState, action: Function) =>
    produce(state, draft => {
        switch (action.type) {
            case "LOGIN_SUCCESS":
                draft.isLoggedIn = true;
                draft.token = action.token;
                break;
            case "LOGOUT":
            case "LOGIN_FAILED":
                draft.isLoggedIn = false;
                draft.token = action.token;
                break;
        }
    });

export default libraryReducer;
