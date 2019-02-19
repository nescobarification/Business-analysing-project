// @flow
import devTools from "remote-redux-devtools";
import { createStore, applyMiddleware, compose } from "redux";
import thunk from "redux-thunk";
import { createLogger } from "redux-logger";
import { persistStore } from "redux-persist";
import reducer from "../reducers";

const logger = createLogger({
    predicate: (getState, action) => !action.type.startsWith("@@redux-form")
});

const enhancer = compose(
    // applyMiddleware(thunk, logger),
    applyMiddleware(thunk),
    devTools({
        name: "nativestarterkit",
        realtime: true
    }));

export default () => {
    const store = createStore(reducer, enhancer);
    const persistor = persistStore(store);

    return { store, persistor };
};
