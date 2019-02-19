// @flow
import * as React from "react";
import { StyleProvider } from "native-base";
import { Provider } from "react-redux";
import { PersistGate } from "redux-persist/integration/react";

import configureStore from "./configureStore";
import App from "../App";
import getTheme from "../theme/components";
import variables from "../theme/variables/platform";

export interface Props { }
export interface State {
    store: Object,
    persistor: Object,
}
export default class Setup extends React.Component<Props, State> {
    constructor() {
        super();
        this.state = configureStore();
        //Uncomment when you modify the initialstate of a persisted reducer to clean the peristance
        //this.state.persistor.purge();
    }

    render() {
        return (
            <StyleProvider style={getTheme(variables)}>
                <Provider store={this.state.store}>
                    <PersistGate loading={null} persistor={this.state.persistor}>
                        <App />
                    </PersistGate>
                </Provider>
            </StyleProvider>
        );
    }
}
