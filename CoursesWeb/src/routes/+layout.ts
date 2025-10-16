import { type Load } from "@sveltejs/kit";
import { loadTranslations, resolveLocaleFromAcceptLanguageHeader } from "@/lib/translations";
import type { LayoutLoad } from "../../.svelte-kit/types/src/routes/$types";

export const load: LayoutLoad = async ({ data, url }) => {
	const { pathname } = url;
	await loadTranslations(data.locale, pathname);
	return { pathname, locale: data.locale, user: data.user };
};
