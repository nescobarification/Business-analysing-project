// @flow
import * as React from "react";
import { connect } from "react-redux";
import { Item, Input, Icon, Form, Text } from "native-base";
import { Field, reduxForm, submit } from "redux-form";
import Login from "../../stories/screens/Login";
import { submitLogin } from "./actions";

const required = value => (value ? undefined : "Required");

export interface Props {
    navigation: any;
    handleSubmit: Function,
    login: Function,
    error: string,
}
export interface State { }
class LoginForm extends React.Component<Props, State> {

    renderInput({ input, label, type, meta: { visited, error } }) {
        return (
            <Item error={ visited && error === "Required" }>
                <Icon active name={input.name === "email" ? "person" : "unlock"} />
                <Input
                    placeholder={input.name === "email" ? "Email" : "Password"}
                    secureTextEntry={input.name === "password" ? true : false}
                    {...input}
                />
            </Item>
        );
    }

    render() {
        const {navigation, handleSubmit, login, error} = this.props;

        const form = (
            <Form onSubmit={handleSubmit}>
                <Field
                    name="email"
                    component={this.renderInput}
                    validate={[required]}
                />
                <Field
                    name="password"
                    component={this.renderInput}
                    validate={[required]}
                />
                {error && <Text error style={{marginLeft: 15}}>{error}</Text>}
            </Form>
        );
        return (
            <Login
                navigation={navigation}
                loginForm={form}
                onLogin={login}
            />
        );
    }
}

const LoginContainer = reduxForm({
    form: "login",
    onSubmit: submitLogin,
    initialValues: {
        email: "test@test.com",
        password: "Test123!",
    }
})(LoginForm);

const  mapDispatchToProps = (dispatch) => ({
    login: () => dispatch(submit("login")),
});

export default connect(null, mapDispatchToProps)(LoginContainer);
