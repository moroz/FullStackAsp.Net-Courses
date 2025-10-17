<script lang="ts">
	import type { User } from "@api/interfaces";

	interface Props {
		user: User;
	}

	const { user }: Props = $props();

	const initials = user.givenName[0] + user.familyName[0];
</script>

<button class="flex h-full items-center justify-center">
	<span
		class="inline-flex aspect-square h-12 items-center justify-center rounded-full bg-primary text-xl font-semibold text-white uppercase"
	>
		{initials}
	</span>
</button>
