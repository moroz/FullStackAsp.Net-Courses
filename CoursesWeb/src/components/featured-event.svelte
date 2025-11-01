<script lang="ts">
	import type { Event } from "@api/interfaces";
	import { MapPin } from "lucide-svelte";
	import { t, locale } from "$lib/translations";
	import { formatDateRange } from "$lib/time-helpers";
	import { formatPrice } from "@/lib/money-helpers";

	interface Props {
		event: Event;
	}

	const { event }: Props = $props();

	let venue = $derived.by(() => {
		if (!event.venue) return null;
		const city =
			$locale === "pl-PL" ? event.venue.cityPl || event.venue.cityEn : event.venue.cityEn;
		const countryName = new Intl.DisplayNames($locale, { type: "region" }).of(
			event.venue.countryCode,
		);
		return `${city}, ${countryName}`;
	});
</script>

<article class="flex justify-between rounded-lg border-2 bg-slate-100 p-6">
	<header>
		<div
			class="mb-2 inline-flex items-center gap-1 rounded border-2 border-black bg-white px-2 py-1 text-sm font-semibold text-primary"
		>
			<MapPin class="h-5 w-5" />
			{#if venue && event.isVirtual}
				<span>{venue} + Online</span>
			{:else if event.venue}
				<span>{venue}</span>
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
		<p>
			{$t(`common.events.event_type.${event.eventType}`)},
			{formatDateRange(event.startsAt, event.endsAt, $locale)}
		</p>
		<p>
			{#if event.basePriceAmount}
				{formatPrice(event.basePriceAmount, event.basePriceCurrency!, $locale)}
			{/if}
		</p>
		<ul>
			{#each event.prices as price}
				<li>{formatPrice(price.priceAmount!, "PLN", $locale)}</li>
			{/each}
		</ul>
	</header>
	{#each event.hosts as host}
		<div class="flex w-35 flex-col items-center overflow-hidden rounded-lg border-2 bg-primary">
			<div class="aspect-square overflow-hidden">
				<img
					src={host.profilePictureUrl}
					class="scale-120"
					alt="Profile picture of {host.salutation} {host.givenName} {host.familyName}"
				/>
			</div>
			<footer class="flex h-10 items-center justify-center text-center text-white">
				<span
					>{#if host.salutation}{$t(host.salutation, { default: host.salutation })}{/if}
					<strong>{host.givenName} {host.familyName}</strong></span
				>
			</footer>
		</div>
	{/each}
</article>
