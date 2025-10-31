import i18n, { type Config } from "sveltekit-i18n";

export const DefaultLocale = "en-GB";
export type LocaleCode = "pl-PL" | "en-GB";
export const SupportedLocales = ["en-GB", "pl-PL"] as const;

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
			locale: "en-GB",
			key: "common",
			loader: async () => {
				return (await import("@/locales/en")).default;
			},
		},
	],
};

export const { t, locale, locales, loading, loadTranslations, setLocale } = new i18n(config);
