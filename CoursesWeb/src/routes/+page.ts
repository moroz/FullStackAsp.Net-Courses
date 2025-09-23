import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ params }) => {
	return {
		test: {
			abc: 42,
			params,
		},
	};
};
