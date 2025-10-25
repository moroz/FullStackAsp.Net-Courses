import i18n, { type Config } from "sveltekit-i18n";
import { parse } from "accept-language-parser";

export const DefaultLocale = "en-US";
export type LocaleCode = "pl-PL" | "en-US";
export const SupportedLocales = ["en-US", "pl-PL"] as const;

const config: Config = {
	loaders: [
		{
			locale: "pl-PL",
			key: "common",
			loader: async () => {
				return (await import("@/locales/pl")).default;
			},
		},
		{
			locale: "en-US",
			key: "common",
			loader: async () => {
				return (await import("@/locales/en")).default;
			},
		},
	],
};

export const { t, locale, locales, loading, loadTranslations, setLocale } = new i18n(config);
