// See https://svelte.dev/docs/kit/types#app.d.ts
// for information about these interfaces
import type { LocaleCode } from "@/lib/translations";

declare global {
	namespace App {
		// interface Error {}
		interface Locals {
			locale: LocaleCode;
		}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
}

export {};
