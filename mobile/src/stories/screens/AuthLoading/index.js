// @flow
import * as React from "react";
import { Spinner, View } from "native-base";
import styles from "./styles";

export interface Props {
    navigation: any,
    isLoggedIn: boolean,
}
export interface State { }
class AuthLoading extends React.Component<Props, State> {

    componentDidMount() {
        this.props.navigation.navigate(this.props.isLoggedIn ? "App" : "Auth");
    }

    render() {
        return (
            <View style={styles.container}>
                <Spinner />
            </View>
        );
    }
}

export default AuthLoading;
