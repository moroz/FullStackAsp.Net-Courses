import type { ISOTimestamp } from "@api/interfaces";
import dayjs from "dayjs";
import tz from "dayjs/plugin/timezone";

export function formatDate(ts: ISOTimestamp | dayjs.Dayjs | Date, locale: "pl" | "en") {
	const date = dayjs(ts).toDate();
	return new Intl.DateTimeFormat(locale, { dateStyle: "full" }).format(date);
}
