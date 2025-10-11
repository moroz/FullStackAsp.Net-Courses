import { type Handle } from "@sveltejs/kit";
import { sequence } from "@sveltejs/kit/hooks";
import parser from "accept-language-parser";
import { DefaultLocale, SupportedLocales } from "@/lib/translations";

const loadSession: Handle = async ({ event, resolve }) => {
	return resolve(event);
};

const resolveLocale: Handle = async ({ event, resolve }) => {
	event.locals.locale =
		parser.pick(SupportedLocales, event.request.headers.get("accept-language") ?? "", {
			loose: true,
		}) ?? DefaultLocale;

	return resolve(event);
};

export const handle = sequence(loadSession, resolveLocale);
