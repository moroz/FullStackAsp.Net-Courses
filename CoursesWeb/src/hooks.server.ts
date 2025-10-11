import { type Handle } from "@sveltejs/kit";
import { sequence } from "@sveltejs/kit/hooks";
import parser from "accept-language-parser";
import { DefaultLocale, SupportedLocales } from "@/lib/translations";
import { maybeLoadSession, SessionCookieName } from "@/lib/session";

const loadSession: Handle = async ({ event, resolve }) => {
	event.locals.session = (await maybeLoadSession(event.cookies.get(SessionCookieName))) ?? {};
	return resolve(event);
};

const resolveLocale: Handle = async ({ event, resolve }) => {
	const localeFromSession = event.locals.session.locale;

	event.locals.locale =
		localeFromSession ??
		parser.pick(SupportedLocales, event.request.headers.get("accept-language") ?? "", {
			loose: true,
		}) ??
		DefaultLocale;

	return resolve(event);
};

export const handle = sequence(loadSession, resolveLocale);
