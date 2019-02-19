// @flow
import { SubmissionError } from "redux-form";
import { URL } from "react-native-dotenv";

interface LoginModel {
	email: string,
	password: string,
}

export async function submitLogin(loginValue: LoginModel, dispatch: Function, props: any) {
	try {
		console.log(URL + "/api/token");
		const res = await fetch(URL + "/api/token", {
			method: "POST",
			headers: {
				"Content-Type": "application/json"
			},
			body: JSON.stringify(loginValue)
		});

		if (res.ok) {
			const json = await res.json();
			dispatch(loginSuccess(json.token));
			props.navigation.navigate("App");
		} else {
			throw ("login failed");
		}

	} catch (e) {
		dispatch(loginFailed());

		throw new SubmissionError({
			_error: "Login failed!"
		});
	}
}

function loginSuccess(token: string) {
	return {
		type: "LOGIN_SUCCESS",
		token: token,
	};
}

function loginFailed() {
	return {
		type: "LOGIN_FAILED",
	};
}
