import { type Handle } from "@sveltejs/kit";
import { sequence } from "@sveltejs/kit/hooks";
import parser from "accept-language-parser";
import { DefaultLocale, SupportedLocales } from "@/lib/translations";
import { maybeLoadSession, saveSession, SessionCookieName } from "@/lib/session";

const loadSession: Handle = async ({ event, resolve }) => {
	event.locals.session = (await maybeLoadSession(event.cookies.get(SessionCookieName))) ?? {};
	return resolve(event);
};

const resolveLocale: Handle = async ({ event, resolve }) => {
	const localeFromSession = event.locals.session.locale;
	const localeFromQueryString = event.url.searchParams.get("lang");

	event.locals.locale =
		(localeFromQueryString || localeFromSession) ??
		parser.pick(SupportedLocales, event.request.headers.get("accept-language") ?? "", {
			loose: true,
		}) ??
		DefaultLocale;

	if (localeFromQueryString) {
		event.locals.session.locale = localeFromQueryString;
		await saveSession(event.locals.session, event.cookies).catch(console.error);
	}

	return resolve(event);
};

export const handle = sequence(loadSession, resolveLocale);
