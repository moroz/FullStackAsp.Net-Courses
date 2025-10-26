import type { ID, ISOTimestamp } from "./common";

export interface Host {
	id: ID;
	salutation: string | null;
	givenName: string;
	familyName: string;
	createdAt: ISOTimestamp;
	updatedAt: ISOTimestamp;
}
