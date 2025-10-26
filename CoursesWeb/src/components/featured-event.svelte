<script lang="ts">
	import type { Event } from "@api/interfaces";
	import { MapPin } from "lucide-svelte";
	import { locale } from "$lib/translations";

	interface Props {
		event: Event;
	}

	const { event }: Props = $props();
</script>

<article class="bg-slate-100 p-6">
	<div
		class="mb-2 inline-flex items-center gap-1 rounded-lg bg-primary px-2 py-1 font-semibold text-white"
	>
		<MapPin class="h-5 w-5" />
		{#if event.venue && event.isVirtual}
			<span>{event.venue} + Online</span>
		{:else if event.venue}
			<span>{event.venue}</span>
		{:else}
			<span>Online</span>
		{/if}
	</div>
	<div class="text-primary"></div>
	<h3 class="text-4xl font-bold text-primary">
		{#if $locale === "pl-PL" && event.titlePl}
			{event.titlePl}
		{:else}
			{event.titleEn}
		{/if}
	</h3>
	{#each event.hosts as host}
		<span>{host.salutation} {host.givenName} {host.familyName}</span>
	{/each}
</article>
