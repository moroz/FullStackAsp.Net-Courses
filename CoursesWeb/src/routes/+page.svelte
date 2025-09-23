<script lang="ts">
	import type { PageProps } from "./$types";

	let { data }: PageProps = $props();
	const events = data.test.events.events[0];
	const startsAt = new Date(events.starts_at.seconds.low * 1000);
</script>

<h1>Welcome to SvelteKit</h1>

<pre>{JSON.stringify(startsAt, null, 2)}</pre>
<pre>{JSON.stringify(events, null, 2)}</pre>
