import color from "color";
import { StyleSheet } from "react-native";
import variables from "../../../theme/variables/platform";

const styles: any = StyleSheet.create({
	container: {
		backgroundColor: "#FBFAFA",
	},
	row: {
		flex: 1,
		alignItems: "center",
	},
	text: {
		fontSize: 20,
		marginBottom: 15,
		alignItems: "center",
	},
	mt: {
		marginTop: 18,
	},
	thumbnail: {
		width: 50,
		height: 90,
	},
	downloadIcon: {
		color: color(variables.brandPrimary).lighten(2)
	}
});
export default styles;
