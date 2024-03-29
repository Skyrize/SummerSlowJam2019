﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionComponent : MonoBehaviour
{
    static private string[] rightAnswers = {
        "Zeus is the king of the gods of Mount Olympus.",
        "Zeus is the child of Cronus and Rhea.",
        "Zeus is married to Hera.",
        "Zeus is the sky and thunder god.",
        "Roman equivalent for Zeus is Jupiter.",
        "Hera is the goddess of women, marriage, family, and childbirth.",
        "Hera is the sister of Zeus.",
        "Hera is the daughter of the Titans Cronus and Rhea.",
        "Hades is the god of the dead and the king of the underworld",
        "Hades was the eldest son of Cronus and Rhea.",
        "Hades, Zeus and Poseidon are brothers.",
        "Cronus is also named Cronos or Kronos.",
        "Cronus and Rhea are titans.",
        "Titans are a race of deities.",
        "Primordial deities are the first gods and goddesses born from the void of Chaos.",
        "The primordial deities Gaia and Uranus give birth to the Titans, and the Cyclopses.",
        "Cult of Dionysos has inspired theatrical culture.",
        "Dionysos is Aphrodite's son.",
        "Medusa was beheaded by Perseus.",
        "Helios is the personification of the sun.",
        "Medusa can turn people to stone.",
        "Pegasus sprang from Medusa's body.",
        "Aphrodite was married to Hephaestus.",
        "Byzantium is the ancient name of Istanbul.",
        "Trojan war has ended because of a wooden horse.",
    };
    static private string[] wrongAnswers = {
        "Zeus is the god of the sea.",
        "Zeus is Hera's father.",
        "Hera is the mother of Zeus.",
        "Roman equivalent for Zeus is Zerator.",
        "Hera is the goddess of love, beauty, pleasure, passion and procreation.",
        "Hades is the last son of Cronus and Rhea.",
        "Hades is the son of Zeus.",
        "Titans are really old humans.",
        "Titans are the first gods and goddesses.",
        "Gaia was a Titan.",
        "Uranus is Poseidon’s brother.",
        "Gaia and Uranus gave birth to Hades and his brothers.",
        "The Titans and the Cyclopses are born from the same parents.",
        "Dionysos is also named Lycos.",
        "Dionysos is also called 'the drunken master'.",
        "Satyrs are sort of cats with wings.",
        "Medusa is the queen of the sea.",
        "Medusa was beheaded by Heracles.",
        "Medusa can turn people to hotdog.",
        "Helios is the personification of rainy days.",
        "Aphrodite was married to Ulysse.",
        "Trojan war has begun because of a wooden horse.",
    };
    public bool answer = false;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0) {
            answer = false;
            text.text = wrongAnswers[Random.Range(0, wrongAnswers.Length - 1)];
        } else {
            answer = true;
            text.text = rightAnswers[Random.Range(0, rightAnswers.Length - 1)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
