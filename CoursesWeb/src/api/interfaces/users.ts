import type { ID, ISOTimestamp } from "./common";

export interface User {
	id: ID;
	email: string;
	givenName: string;
	familyName: string;
	createdAt: ISOTimestamp;
	lastLoginAt: ISOTimestamp | null;
}
