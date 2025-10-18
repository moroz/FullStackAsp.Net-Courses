<script lang="ts">
	import { t } from "$lib/translations";
	import { twMerge } from "tailwind-merge";
	import type { HTMLInputAttributes } from "svelte/elements";

	interface Props extends HTMLInputAttributes {
		labelKey: string;
		class?: string;
	}

	let { name, labelKey, value = $bindable(), class: className, ...rest }: Props = $props();
</script>

<label class="grid gap-1">
	<span class="leading-tight font-bold">{$t(labelKey)}</span>
	<input
		type="text"
		bind:value
		{name}
		class={twMerge("h-10 rounded-sm border border-slate-500 px-3", className)}
		{...rest}
	/>
</label>
