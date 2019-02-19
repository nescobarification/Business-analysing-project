import * as React from "react";
import { Container, Content, Header, Body, Title, Button, Text, View, Thumbnail } from "native-base";
import styles from "./styles";

export interface Props {
	loginForm: any,
	onLogin: Function,
}
export interface State {}
class Login extends React.Component<Props, State> {
	render() {
		return (
			<Container>
				<Header style={styles.header}>
					<Body style={{ alignItems: "center" }}>
						<Thumbnail large source={require("../../components/images/inovva.png")} />
						<Title style={ styles.paddingTopSmall }>PFE</Title>
					</Body>
				</Header>
				<Content>
					{this.props.loginForm}
					<View padder>
						<Button block style={ styles.btn } onPress={() => this.props.onLogin()}>
							<Text>Login</Text>
						</Button>
					</View>
				</Content>
			</Container>
		);
	}
}

export default Login;
