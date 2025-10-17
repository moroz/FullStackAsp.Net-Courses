import { loadTranslations } from "$lib/translations";
import type { LayoutLoad } from "./$types";

export const load: LayoutLoad = async ({ data, url }) => {
	const { pathname } = url;
	await loadTranslations(data.locale, pathname);
	return { pathname, locale: data.locale, user: data.user };
};
