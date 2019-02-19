import * as React from "react";
import { Button, Icon, ActionSheet } from "native-base";

export interface Props {
    sortList: Function,
}
export interface State { }

export default class FilterButton extends React.Component<Props, State> {
    render() {
        const {sortList} = this.props;

        return (
            <Button transparent>
            <Icon
                active
                name="funnel"
                onPress={() =>
                    ActionSheet.show(
                        {
                            options: ["Recent", "Title", "Cancel"],
                            cancelButtonIndex: 2,
                            title: "Order by:"
                        },
                        buttonIndex => {
                            if (buttonIndex <= 1) {
                                sortList(buttonIndex);
                            }
                        }
                    )
                }
            />
            </Button>
        );
    }
}
