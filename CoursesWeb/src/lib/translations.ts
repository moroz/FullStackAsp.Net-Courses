import i18n, { type Config } from "sveltekit-i18n";
import { parse } from "accept-language-parser";

export const DefaultLocale = "en";
export type LocaleCode = "pl" | "en";
export const SupportedLocales = ["en", "pl"] as const;

const config: Config = {
	loaders: [
		{
			locale: "pl",
			key: "common",
			loader: async () => {
				return (await import("@/locales/pl")).default;
			},
		},
		{
			locale: "en",
			key: "common",
			loader: async () => {
				return (await import("@/locales/en")).default;
			},
		},
	],
};

export function resolveLocaleFromAcceptLanguageHeader(header: string): LocaleCode {
	const languages = parse(header);
	const found = languages.find(({ code }) => ["pl", "en"].includes(code));
	return (found?.code ?? DefaultLocale) as LocaleCode;
}

export const { t, locale, locales, loading, loadTranslations, setLocale } = new i18n(config);
