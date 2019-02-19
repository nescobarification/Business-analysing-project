import * as React from "react";
import { Container, Content, Text, Button } from "native-base";
import BackButton from "../../components/BackButton";
import HeaderNav from "../../components/HeaderNav";
import RNFetchBlob from "react-native-fetch-blob";
import { URL } from "react-native-dotenv";

import styles from "./styles";
export interface Props {
	navigation: any,
	token: string,
}
export interface State { }
class BlankPage extends React.Component<Props, State> {
	constructor() {
		super();
		this.state = {
			status: -1,
			bodyText: "a"
		};
	}

	onPress() {
		// Use to test the server
		const res = fetch(URL + "/api/sync", {
			method: "GET",
			headers: {
				"Content-Type": "application/json",
				"Authorization": "Bearer " + this.props.token
			},
		})
		.then(res => {
			this.setState(() => {
				return {
					status: res.status,
					bodyText: res._bodyText
				};
			});
		})
		.catch(() => {
			console.log("Error while get to the server.");
		});
	}

	render() {
		const param = this.props.navigation.state.params;
		return (
			<Container style={styles.container}>
				<HeaderNav navigation={this.props.navigation} button={BackButton} title="BlankPage"/>

				<Content padder>
					<Text>{param !== undefined ? param.name.item : "Create Something Awesome . . ."}</Text>
					<Text>{this.state.status.toString()}</Text>
					<Text>{this.state.bodyText}</Text>
					<Button onPress={() => this.onPress()}>
						<Text>Test api</Text>
					</Button>
				</Content>
			</Container>
		);
	}
}

export default BlankPage;
