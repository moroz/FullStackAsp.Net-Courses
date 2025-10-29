import type { ID, ISOTimestamp } from "./common";
import type { Host } from "./hosts";

export const EventTypeValues = ["Seminar", "Webinar"] as const;

export type EventType = "Seminar" | "Webinar";

export interface Event {
	id: ID;
	titleEn: string;
	titlePl: string | null;
	venue: Venue | null;
	startsAt: ISOTimestamp;
	endsAt: ISOTimestamp;
	createdAt: ISOTimestamp;
	updatedAt: ISOTimestamp;
	descriptionPl: string | null;
	descriptionEn: string;
	isVirtual: boolean;
	hosts: Host[];
	eventType: EventType;
}

export interface Venue {
	id: ID;
	nameEn: string;
	namePl: string | null;
	countryCode: string;
	cityEn: string;
	cityPl: string | null;
	postalCode: string | null;
	street: string;
}
