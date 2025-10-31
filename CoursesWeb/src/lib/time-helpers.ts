import type { AnyDate, ISOTimestamp } from "@api/interfaces";
import dayjs from "dayjs";
import tz from "dayjs/plugin/timezone";

export function normalizeDate(ts: AnyDate) {
	return dayjs(ts).toDate();
}

export function formatDate(
	ts: ISOTimestamp | dayjs.Dayjs | Date,
	locale: string,
	opts?: Intl.DateTimeFormatOptions,
) {
	const date = normalizeDate(ts);
	return new Intl.DateTimeFormat(locale, {
		month: "numeric",
		day: "numeric",
		year: "numeric",
		...opts,
	}).format(date);
}

export function isSameDate(startsAt: AnyDate, endsAt: AnyDate) {
	return dayjs(startsAt).isSame(dayjs(endsAt), "date");
}

export function formatDateRange(startsAt: AnyDate, endsAt: AnyDate, locale: string) {
	if (isSameDate(startsAt, endsAt)) {
		return formatDate(startsAt, locale);
	}

	const start = formatDate(startsAt, locale, { year: undefined });
	const end = formatDate(endsAt, locale);
	return `${start}–${end}`;
}
