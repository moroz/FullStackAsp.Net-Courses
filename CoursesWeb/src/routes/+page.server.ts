import { CoursesApiClient } from "../api/client";
import type { PageServerLoad } from "./$types";
import { promisify } from "util";
import { listEvents } from "../api/queries";

export const load: PageServerLoad = async ({ params }) => {
	const events = await listEvents();
	return {
		events,
	};
};
