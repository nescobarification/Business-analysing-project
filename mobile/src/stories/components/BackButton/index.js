import * as React from "react";
import { Button, Icon } from "native-base";

export interface Props {
    navigation: any,
}
export interface State { }

export default class BackButton extends React.Component<Props, State> {
    render() {
        return (
            <Button transparent onPress={() => this.props.navigation.goBack()}>
                <Icon name="ios-arrow-back" />
            </Button>
        );
    }
}
