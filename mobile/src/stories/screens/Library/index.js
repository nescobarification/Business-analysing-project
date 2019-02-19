// @flow
import React, { Component } from "react";
import { RefreshControl, FlatList as List } from "react-native";
import { Container, Content, Text, Body, ListItem, Thumbnail, Right, Icon } from "native-base";
import HeaderNav from "../../components/HeaderNav";
import DrawerButton from "../../components/DrawerButton";
import FilterButton from "../../components/FilterButton";
import FooterNav from "../../components/FooterNav";
import { PdfInfo } from "../../../reducers/state-typed";
import styles from "./styles";

export interface Props {
    navigation: any,
    isLoading: boolean,
    list: Array<PdfInfo>,
    sortList: Function,
    onRefresh: Function,
    onPressItem: Function,
    onLongPressItem: Function,
    downloadOnlyMode: boolean,
}
export interface State { }
class Library extends Component<Props, State> {
    render() {
        const { navigation, list, sortList, isLoading, onRefresh } = this.props;

        return (
            <Container style={styles.container}>
                <HeaderNav navigation={navigation} button={DrawerButton} title="HomePage">
                    <FilterButton sortList={sortList} />
                </HeaderNav>
                <Content
                    refreshControl={
                        <RefreshControl
                            refreshing={isLoading}
                            onRefresh={onRefresh} />}>
                    <List
                        data={list}
                        extraData={this.props.downloadOnlyMode}
                        keyExtractor={(item, index) => item.id.toString()}
                        renderItem={(data: {item:PdfInfo}) => {
                            let item = data.item;
                            return this._renderItem(item, this.props.downloadOnlyMode);
                        }} />
                </Content>
                <FooterNav navigation={navigation} page="Library" />
            </Container>
        );
    }

    _renderItem(item: PdfInfo, downloadOnlyMode: boolean) {
        if (downloadOnlyMode && !item.pdfOption.isDownloaded) {
            return (
                <ListItem disabled key={item.id.toString()}>
                    <Thumbnail square style={styles.thumbnail} source={{ uri: item.cover }} />
                    <Body>
                        <Text disabled>{item.title}</Text>
                    </Body>
                </ListItem>
            );
        }

        const { navigation, onPressItem, onLongPressItem } = this.props;

        return (
            <ListItem
                key={item.id.toString()}
                onPress={() => {onPressItem(item.id); navigation.navigate("PdfView");}}
                onLongPress={() => onLongPressItem(item.id, item.pdfOption.isDownloaded) }>
                <Thumbnail square style={styles.thumbnail} source={{ uri: item.cover }} />
                <Body>
                    <Text>{item.title}</Text>
                    <Text note>{item.subtitle}</Text>
                </Body>
                { item.pdfOption.isDownloaded &&
                    <Right>
                        <Icon style={styles.downloadIcon} name="checkmark-circle" />
                    </Right>
                }
            </ListItem>
        );
    }
}

export default Library;
