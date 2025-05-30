import Link from "next/link";
import MainMenu from "@/componets/layout/MainMenu";

export default function ContactPage() {
    return (
        <div className="p-8">
            <MainMenu />
            <h1 className="text-2xl font-bold">Contact me</h1>
            <p className="mt-4">Contact me.</p>
        </div>
    )
}
