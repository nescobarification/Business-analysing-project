import reducer from "../reducer";

describe("list reducer", () => {
	it("should return the initial state", () => {
		expect(reducer(undefined, {})).toEqual({
			list: [],
			isLoading: true,
		});
	});

	it("should handle FETCH_LIBRARY_SUCCESS", () => {
		expect(
			reducer([], {
				type: "FETCH_LIBRARY_SUCCESS",
				list: [
					{
						title: "title",
						subtitle: "subtitle",
						cover: "cover",
						link: "link",
						metadata: []
					},
				],
			})
		).toEqual({
			list: [
				{
					title: "title",
					subtitle: "subtitle",
					cover: "cover",
					link: "link",
					metadata: []
				}
			],
		});
	});
	it("should handle LIBRARY_IS_LOADING", () => {
		expect(
			reducer([], {
				type: "LIBRARY_IS_LOADING",
				isLoading: false,
			})
		).toEqual({
			isLoading: false,
		});
	});
});
