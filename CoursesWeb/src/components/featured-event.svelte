<script lang="ts">
	import type { Event } from "@api/interfaces";
	import { MapPin } from "lucide-svelte";
	import { locale } from "$lib/translations";

	interface Props {
		event: Event;
	}

	const { event }: Props = $props();
</script>

<article class="flex bg-slate-100 p-6">
	<header>
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
	</header>
	{#each event.hosts as host}
		<div
			class="flex w-35 flex-col items-center overflow-hidden rounded-lg bg-primary text-white shadow outline"
		>
			<div class="aspect-square overflow-hidden">
				<img
					src={host.profilePictureUrl}
					alt="Profile picture of {host.salutation} {host.givenName} {host.familyName}"
				/>
			</div>
			<footer class="flex h-10 items-center justify-center text-center">
				<span>{host.salutation} <strong>{host.givenName} {host.familyName}</strong></span>
			</footer>
		</div>
	{/each}
</article>
