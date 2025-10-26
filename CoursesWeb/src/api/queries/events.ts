import { CoursesApiClient } from "../client";
import { promisify } from "util";
import { type Event } from "../interfaces";
import { timestampToISO } from "../helpers";

export async function listEvents(): Promise<Event[]> {
	const client = new CoursesApiClient();
	const events = await promisify(client.client.listEvents).call(client.client, {});

	if (!events?.events) return [];

	return events.events.map((e) => ({
		id: e.id!.value,
		titleEn: e.titleEn,
		titlePl: e.titlePl?.value ?? null,
		venue: e.venue?.value ?? null,
		startsAt: timestampToISO(e.startsAt)!,
		endsAt: timestampToISO(e.endsAt)!,
		createdAt: timestampToISO(e.createdAt)!,
		updatedAt: timestampToISO(e.updatedAt)!,
		descriptionEn: e.descriptionEn,
		descriptionPl: e.descriptionPl?.value ?? null,
		isVirtual: e.isVirtual,
		hosts: e.hosts.map((h) => ({
			id: h.id!.value,
			salutation: h.salutation ?? null,
			givenName: h.givenName,
			familyName: h.familyName,
			profilePictureUrl: h.profilePictureUrl ?? null,
			createdAt: timestampToISO(h.createdAt)!,
			updatedAt: timestampToISO(h.updatedAt)!,
		})),
	}));
}
