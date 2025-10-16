// See https://svelte.dev/docs/kit/types#app.d.ts
// for information about these interfaces
import type { LocaleCode } from "@/lib/translations";
import type { User } from "@api/interfaces";

declare global {
	namespace App {
		// interface Error {}
		interface Locals {
			locale: LocaleCode;
			session: Record<string, any>;
			user: User | null;
		}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
}

export {};
