import Link from "next/link";
import MainMenu from "@/componets/layout/MainMenu";

export default function AboutPage() {
    return (
        <div className="p-8">
            <MainMenu />
            <h1 className="text-2xl font-bold">About me</h1>
            <p className="mt-4">This is the about page of my Next.js application.</p>
        </div>
    )
}
