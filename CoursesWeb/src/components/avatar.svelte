<script lang="ts">
	import type { User } from "@api/interfaces";
	import { twMerge } from "tailwind-merge";

	interface Props {
		user: User;
		class?: string;
	}

	const { user, class: className }: Props = $props();
	const initials = user.givenName[0] + user.familyName[0];
</script>

<span
	class={twMerge(
		"inline-flex aspect-square h-10 items-center justify-center rounded-full bg-primary text-lg font-semibold text-white uppercase",
		className,
	)}
>
	{initials}
</span>
