import dayjs from "dayjs";

export type ISOTimestamp = string;
export type ID = string;

export type AnyDate = Date | dayjs.Dayjs | ISOTimestamp;
