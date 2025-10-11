import type { LayoutLoad, LayoutServerLoad } from "../../.svelte-kit/types/src/routes/$types";

export const load: LayoutServerLoad = ({ locals }) => {
	return {
		locale: locals.locale,
	};
};
