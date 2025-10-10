<script lang="ts">
	import type { Event } from "@api/interfaces";
	interface Props {
		event: Event;
	}

	const { event }: Props = $props();
</script>

<article class="bg-slate-100 p-6">
	<div class="flex">
		{#if event.venue && event.isVirtual}
			<span>{event.venue} + Online</span>
		{:else if event.venue}
			<span>{event.venue}</span>
		{:else}
			<span>Online</span>
		{/if}
	</div>
	<h3 class="text-4xl font-bold text-primary">{event.titleEn}</h3>
</article>
