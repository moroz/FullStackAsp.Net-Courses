import { CoursesApiClient } from "../api/client";
import type { PageServerLoad } from "./$types";
import { promisify } from "util";

export const load: PageServerLoad = async ({ params }) => {
	const client = new CoursesApiClient();
	const events = await promisify(client.client.listEvents).call(client.client, {});

	return {
		test: {
			abc: 42,
			events: JSON.parse(JSON.stringify(events)),
		},
	};
};
