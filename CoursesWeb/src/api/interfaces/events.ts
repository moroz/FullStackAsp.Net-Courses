import type { ID, ISOTimestamp } from "./common";

export interface Event {
	id: ID;
	titleEn: string;
	titlePl: string | null;
	venue: string | null;
	startsAt: ISOTimestamp;
	endsAt: ISOTimestamp;
	createdAt: ISOTimestamp;
	updatedAt: ISOTimestamp;
	descriptionPl: string | null;
	descriptionEn: string;
	isVirtual: boolean;
}
