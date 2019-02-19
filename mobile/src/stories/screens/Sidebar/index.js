import React, { Component } from "react";
import { Switch } from "react-native";
import { Text, Container, Item, List, ListItem, Content, Icon, Left, Right, Body, Footer, Button, Thumbnail } from "native-base";
import styles from "./styles";

export interface Props {
	navigation: any,
	downloadOnlyMode: boolean,
	toggleDownloadOnlyMode: Function,
	logout: Function,
}
export interface State { }
export default class Sidebar extends Component<Props, State> {
	render() {
		const { navigation, downloadOnlyMode, toggleDownloadOnlyMode, logout } = this.props;

		return (
			<Container style={styles.container}>
				<Content>
					<Item style={styles.body}>
						<Thumbnail small style={ styles.headerLogo } source={require("../../components/images/inovva.png")} />
						<Text style={ styles.headerText }>PFE</Text>
					</Item>
					<List>
						<ListItem button icon style={styles.listItem}
							onPress={() => navigation.navigate("Library")}>
							<Left>
								<Icon style={styles.listItemIcon} name="home" />
							</Left>
							<Body>
								<Text style={styles.listItemText}>Library</Text>
							</Body>
						</ListItem>
						<ListItem button icon style={styles.listItem}
							onPress={() => navigation.navigate("BlankPage")}>
							<Left>
								<Icon style={styles.listItemIcon} name="document" />
							</Left>
							<Body>
								<Text style={styles.listItemText}>Blank Page</Text>
							</Body>
						</ListItem>
						<ListItem button icon style={styles.listItem}
							onPress={() => navigation.navigate("BlankPage")}>
							<Left>
								<Icon style={styles.listItemIcon} name="settings" />
							</Left>
							<Body>
								<Text style={styles.listItemText}>Settings</Text>
							</Body>
						</ListItem>
						<ListItem button icon style={styles.listItem}
							onPress={() => toggleDownloadOnlyMode()}>
							<Left>
								<Icon style={styles.listItemIcon} name="cloud-download" />
							</Left>
							<Body>
								<Text style={styles.listItemText}>Downloaded Only</Text>
							</Body>
							<Right>
								<Switch
									value={downloadOnlyMode}
									onValueChange={() => toggleDownloadOnlyMode()} />
							</Right>
						</ListItem>
					</List>
				</Content>
				<Footer>
					<Button
						full
						danger
						style={styles.btnLogout}
						onPress={() => {logout(); navigation.navigate("Auth");}}>
						<Icon name="log-out" />
						<Text>Logout</Text>
					</Button>
				</Footer>
			</Container>
		);
	}
}
