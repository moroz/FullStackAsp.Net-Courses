import type { ID, ISOTimestamp } from "./common";

export interface Host {
	id: ID;
	salutation: string | null;
	givenName: string;
	familyName: string;
	profilePictureUrl: string | null;
	createdAt: ISOTimestamp;
	updatedAt: ISOTimestamp;
}
