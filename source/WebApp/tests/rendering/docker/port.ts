export function setPortFromSetup(port: string) {
    process.env.TEST_DOCKER_CHROME_PORT = port;
}
export default process.env.TEST_DOCKER_CHROME_PORT!;