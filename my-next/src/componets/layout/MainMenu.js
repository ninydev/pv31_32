import Link from "next/link";

export default function MainMenu() {
    return (
        <nav className="flex gap-4 mb-4">
        <Link href="/" className="hover:underline">
            Home
        </Link>
        <Link href="/about" className="hover:underline">
            About
        </Link>
        <Link href="/contact" className="hover:underline">
            Contact
        </Link>
        <Link href="/cats" className="hover:underline">
            Cats
        </Link>
        </nav>
    );
}
