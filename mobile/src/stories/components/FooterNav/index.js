import React, { Component } from "react";
import { Footer, FooterTab, Button, Icon, Text } from "native-base";
import { NavigationActions } from "react-navigation";

export interface Props {
    navigation: any,
    page: string,
}

class FooterNav extends Component<Props, State> {
    goto(page:string) {
        return this.props
            .navigation
            .dispatch(NavigationActions.reset(
                {
                    index: 0,
                    actions: [
                        NavigationActions.navigate({ routeName: page})
                    ]
                }));
    }

    render() {
        return (
            <Footer>
                <FooterTab>
                    <Button vertical
                        active={this.props.page.toLowerCase() === "library"}
                        onPress={() => this.goto("Drawer")}>
                        <Icon name="home" />
                        <Text>Home</Text>
                    </Button>
                    <Button vertical disabled
                        active={this.props.page.toLowerCase() === "navigate"}>
                        <Icon active name="compass" />
                        <Text>Navigate</Text>
                    </Button>
                    <Button vertical disabled
                        active={this.props.page.toLowerCase() === "shop"}>
                        <Icon name="cart" />
                        <Text>Shop</Text>
                    </Button>
                </FooterTab>
            </Footer>
        );
    }
}

export default FooterNav;
