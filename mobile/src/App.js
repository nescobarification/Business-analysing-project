// @flow
import React from "react";
import { SwitchNavigator, StackNavigator, DrawerNavigator } from "react-navigation";
import { Root } from "native-base";
import AuthLoading from "./container/AuthLoadingContainer";
import Login from "./container/LoginContainer";
import BlankPage from "./container/BlankPageContainer";
import PdfView from "./container/PdfViewContainer";
import Sidebar from "./container/SidebarContainer";
import Library from "./container/LibraryContainer";

const Drawer = DrawerNavigator(
	{
		Library: { screen: Library },
	},
	{
		initialRouteName: "Library",
		contentComponent: props => <Sidebar {...props} />,
	}
);

const AppStack = StackNavigator(
	{
		BlankPage: { screen: BlankPage },
		PdfView: { screen: PdfView },
		Drawer: { screen: Drawer },
	},
	{
		initialRouteName: "Drawer",
		headerMode: "none",
	}
);
const AuthStack = StackNavigator(
	{ 
		Login: { screen: Login },
	},
	{
		initialRouteName: "Login",
		headerMode: "none",
	}
);

const App = SwitchNavigator(
	{
		AuthLoading: { screen: AuthLoading },
		App: AppStack,
		Auth: AuthStack,
	},
	{
		initialRouteName: "AuthLoading",
	}
);

export default () => (
	<Root>
		<App />
	</Root>
);
