import * as React from "react";
import { Header, Left, Body, Title, Right } from "native-base";

export interface Props {
    navigation: any,
    button: any,
    title: any,
}
export interface State { }

export default class HeaderNav extends React.Component<Props, State> {
    render() {
        const Button = this.props.button;
        const title = this.props.title;

        return (
            <Header>
                <Left>
                    <Button navigation={this.props.navigation} />
                </Left>

                <Body style={{ flex: 3 }}>
                    <Title>{title}</Title>
                </Body>

                <Right>{this.props.children}</Right>
            </Header>
        );
    }
}
