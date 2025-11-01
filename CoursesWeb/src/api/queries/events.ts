import { CoursesApiClient } from "../client";
import { promisify } from "util";
import { type Event, EventTypeValues, type EventType } from "../interfaces";
import { decodeDecimal, timestampToISO } from "../helpers";

export async function listEvents(): Promise<Event[]> {
	const client = new CoursesApiClient();
	const events = await promisify(client.client.listEvents).call(client.client, {});

	if (!events?.events) return [];

	return events.events.map((e) => ({
		id: e.id!.value,
		titleEn: e.titleEn,
		titlePl: e.titlePl?.value ?? null,
		startsAt: timestampToISO(e.startsAt)!,
		endsAt: timestampToISO(e.endsAt)!,
		createdAt: timestampToISO(e.createdAt)!,
		updatedAt: timestampToISO(e.updatedAt)!,
		descriptionEn: e.descriptionEn,
		descriptionPl: e.descriptionPl?.value ?? null,
		isVirtual: e.isVirtual,
		eventType: EventTypeValues[e.eventType as keyof typeof EventTypeValues] as EventType,
		basePriceAmount: decodeDecimal(e.basePriceAmount ?? null)?.toString() ?? null,
		basePriceCurrency: e.basePriceCurrency?.value || null,
		hosts: e.hosts.map((h) => ({
			id: h.id!.value,
			salutation: h.salutation ?? null,
			givenName: h.givenName,
			familyName: h.familyName,
			profilePictureUrl: h.profilePictureUrl ?? null,
			createdAt: timestampToISO(h.createdAt)!,
			updatedAt: timestampToISO(h.updatedAt)!,
		})),
		venue: e.venue
			? {
					id: e.venue.id!.value,
					nameEn: e.venue.nameEn,
					namePl: e.venue.namePl || null,
					countryCode: e.venue.countryCode,
					cityEn: e.venue.cityEn,
					cityPl: e.venue.cityPl || null,
					postalCode: e.venue.postalCode || null,
					street: e.venue.street,
				}
			: null,
		prices: e.prices.map((p) => ({
			id: p.id!.value,
			priceAmount: decodeDecimal(p.priceAmount)!.toString(),
			priceCurrency: p.priceCurrency,
		})),
	}));
}
